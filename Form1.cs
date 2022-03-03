using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;
using System.Collections.Generic;
using System.Xml;
using Oracle.ManagedDataAccess.Client;
using System.Data;

/// <summary>
/// IP 주소로 PC에 해당 포트가 오픈되어 있는지 확인. 
/// </summary>

namespace IPScanner
{

	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// 버튼 클릭 해서 왔는지 체크 ( 설정 클릭시도 Tick작업을 하니까 )
		//Boolean BtnCheck = false;
		private long tmr = 0;
		OracleConnection pgOraConn;
		OracleCommand pgOraCmd;

		// 구조체 선언
		struct ItemInfo
		{
			public string Server;
			public string Equip;
			public string IP;
			public int Port;

		}

		// 읽어온 정보를 담을 List 생성
		List<ItemInfo> itemInfoList = new List<ItemInfo>();
		private string _strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.12.11.131)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User ID=MESMGR2;Password=MESMGR2;Connection Timeout=30;";

		// DB 연결
		private bool ConnectionDBOpen(string dbIp, string dbName, string dbId, string dbPw)
		{
			bool retValue = false;
			try
			{
				// 오라클 서버 연결 객체 생성
				pgOraConn = new OracleConnection($"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={dbIp})(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={dbName})));User ID={dbId};Password={dbPw};Connection Timeout=30;");
				// OPEN
				pgOraConn.Open();
				// 명령 객체 생성
				pgOraCmd = pgOraConn.CreateCommand();
				// 연결 성공
				retValue = true;
			}
			catch (Exception e)
			{
				// 연결 실패
				retValue = false;
				MessageBox.Show($"DB connection fail.\n {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return retValue;
		}

		/// <summary>
		/// 참고용으로만 적어 놓았음.
		/// </summary>
		/// <param name="StrQuery"></param>
		private void DataRead(string StrQuery)
		{

			OracleCommand cmd = new OracleCommand();

			cmd.Connection = pgOraConn;

			cmd.CommandText = StrQuery; 

			// 결과 리더 객체를 리턴
			OracleDataReader rdr = cmd.ExecuteReader();

			// 레코드 계속 가져와서 루핑

			while (rdr.Read())
			{

				// 필드 데이타 읽기

				string s = rdr["LOT_ID"] as string;

				// 데이타를 리스트박스에 추가
				//listBox1.Items.Add(s);

			}

			// 사용후 닫음
			rdr.Close();
		}

		/// <summary>
		/// Equip / IP / Port 를 받아 현재 상태를 DB에 저장함.
		/// </summary>
		/// <param name="Equip"></param>
		/// <param name="IP"></param>
		/// <param name="Port"></param>
		private void DataInsert(string Server, string Equip, string IP, string Port, String LiveIP, String LivePort, String LiveConnection)
		{
			OracleTransaction STrans = null;  //오라클 트랜젝션

			STrans = pgOraConn.BeginTransaction();

			// 명령 객체 생성
			OracleCommand cmd = new OracleCommand("", pgOraConn);
			cmd.Connection = pgOraConn;

			try
			{
				cmd.Transaction = STrans;  //커맨드에 트랜젝션 명시
				// SQL문 지정 및 INSERT 실행
				cmd.CommandText = "insert into IPStatus values ( NO_SEQ.NEXTVAL, '" + Server + "','" + Equip + "','" + IP + "','" + Port + "','" + LiveIP + "','" + LivePort + "','" + LiveConnection + "','" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + "')";
				cmd.ExecuteNonQuery();
				// 커밋
				cmd.Transaction.Commit();   
			}

			catch(Exception ex)
			{
				// 롤백
				cmd.Transaction.Rollback();   
			}
			finally{
				cmd.Dispose();
			}

		}

		public void LoadXML()
		{

			// 읽어올 파일 경로
			string fileAndPath = lbl_FileChoice.Text.ToString();

			// XmlReader 로 xml 파일 읽어오기
			XmlReader xmlReader;

			try
			{
				if ( lbl_FileChoice.Text.Trim() == "")
				{
					MessageBox.Show("장비 설정 파일을 선택하시기 바랍니다.");
					return;
				}

				XmlReaderSettings setting = new XmlReaderSettings();
				setting.IgnoreComments = true;
				setting.IgnoreWhitespace = true;
				xmlReader = XmlReader.Create(fileAndPath, setting);
			}
			catch (System.Exception e)
			{
				return;
			}

			while (xmlReader.Read())   // xml 파일 노드 별로 읽기
			{
				// 읽은 노드가 Item 의 시작노드라면 정보 읽기
				if (xmlReader.Name.CompareTo("Item".ToUpper()) == 0 &&
					  xmlReader.NodeType == XmlNodeType.Element)
				{
					ItemInfo newItemInfo = new ItemInfo();

					try
					{
						if (xmlReader.MoveToFirstAttribute())    // 첫 번째 속성이 있다면..
						{
							do
							{
								string AttribName = xmlReader.Name;

								if (AttribName.CompareTo("Server".ToUpper()) == 0)
									newItemInfo.Server = xmlReader.Value;
								else if (AttribName.CompareTo("Equip".ToUpper()) == 0)
									newItemInfo.Equip = xmlReader.Value;
								else if (AttribName.CompareTo("IP".ToUpper()) == 0)
									newItemInfo.IP = xmlReader.Value;
								else if (AttribName.CompareTo("Port".ToUpper()) == 0)
									newItemInfo.Port = int.Parse(xmlReader.Value);
							} while (xmlReader.MoveToNextAttribute());
							// 다음 속성으로 이동 & 있다면 반복..
						}
					}
					catch (System.Exception e)
					{
						Console.WriteLine(e.Message);
						Console.WriteLine(@"..\..\ItemInfo2.xml 아이템 테이블을 확인하세요.");
						return;
					}

					// List 에 newItemInfo 추가
					itemInfoList.Add(newItemInfo);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{

			try
			{
				// DB연결및 Open
				ConnectionDBOpen("10.12.11.131", "orcl", "MESMGR2", "MESMGR2");

				// 데이터 읽는 방법 기술 
				// DataRead("SELECT * FROM CEDCINPFHS");

				// IP리스트 xml 읽어오기
				LoadXML();

				Cursor.Current = Cursors.WaitCursor;

				// List 에 저장된 정보 확인 ( 돌면서 확인 )
				foreach (ItemInfo eachInfo in itemInfoList)

				{
					if (PingTest(eachInfo.IP))
					{
						// 해당 포트 테스트
						if (ConnectTest(eachInfo.IP, eachInfo.Port))
						{
							// 인서트 처리 ( Ping도 되고 Port도 잘 된 경우 )
							DataInsert(eachInfo.Server, eachInfo.Equip, eachInfo.IP, eachInfo.Port.ToString(),"Y","Y","Y");
						}
						else
						{
							// 인서트 처리 ( Ping은 되는데 Port가 막힌 경우 )
							DataInsert(eachInfo.Server, eachInfo.Equip, eachInfo.IP, eachInfo.Port.ToString(), "Y", "N", "N");
						}
					}
					else
					{
						// 인서트 처리 ( Ping도 안되고 Port도 막힌 경우 )
						DataInsert(eachInfo.Server, eachInfo.Equip, eachInfo.IP, eachInfo.Port.ToString(), "N", "N", "N");
					}
				}

				Cursor.Current = Cursors.Default;

				// DB 닫기
				pgOraCmd.Dispose();
				pgOraConn.Close();

			}
			catch (Exception)
			{

			}
			finally
			{
				pgOraCmd.Dispose();
				pgOraConn.Close();
			}
		}

		/// <summary>
		///  Ping테스트하기
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		private static bool PingTest(string ip)
		{
			bool result = false;
			try
			{
				Ping pp = new Ping();
				PingOptions po = new PingOptions();
				po.DontFragment = true;
				byte[] buf = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaa");
				PingReply reply = pp.Send(IPAddress.Parse(ip), 10, buf, po);
				if (reply.Status == IPStatus.Success)
				{
					result = true;
				}
				else
				{
					result = false;
				}
				return result;
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ip와 포트를 이용하여 연결 테스트
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="port"></param>
		/// <returns></returns>
		private static bool ConnectTest(string ip, int port)
		{
			bool result = false; Socket socket = null;
			try
			{
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, false);
				IAsyncResult ret = socket.BeginConnect(ip, port, null, null);
				result = ret.AsyncWaitHandle.WaitOne(100, true);
			}
			catch
			{ }
			finally
			{
				if (socket != null)
				{
					socket.Close();
				}
			}
			return result;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				Schedule_Timer.Enabled = true;
			}
			catch
			{

			}
		}

		private void Schedule_Timer_Tick(object sender, EventArgs e)
		{
			tmr++;
			lblTmr.Text = tmr.ToString();
			// 1분계산
			if ((tmr) > int.Parse(numericUpDown1.Value.ToString()) * 60)
			{
				// 타이머를 발동시킨다.
				Schedule_Timer.Start();

				// 시간마다 자동 시작
				button1.PerformClick();
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();

			open.Filter = "XML File(*.xml)|*.xml|AllFiles(*.*)|*.*";
			open.InitialDirectory = @"C:\";
			open.Title = "장비 설정 파일을 선택해 주십시오";

			if (open.ShowDialog() == DialogResult.OK)
			{
				this.lbl_FileChoice.Text = open.FileName;
			}

		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			pictureBox1.Cursor = Cursors.Hand;
		}

		private void pictureBox1_MouseHover(object sender, EventArgs e)
		{
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.Image = Properties.Resources.Folder_sort_svg;

		}

		private void pictureBox1_MouseLeave(object sender, EventArgs e)
		{
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.Image = Properties.Resources.Folder_svg;

		}

		private void button1_MouseMove(object sender, MouseEventArgs e)
		{
			button1.Cursor = Cursors.Hand;
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			// 시스템 트레이에서의 아이콘이 더블클릭되었을때의 이벤트

			// 윈도우의 모습을 보인다.
			this.Visible = true;
			// 아이콘의 모습을 보인다.
			this.ShowIcon = true;
			// 시스템트레이의 모습을 감춘다.
			notifyIcon1.Visible = false;
			// 윈도우 중간으로 나오도록
			this.WindowState = FormWindowState.Normal;

		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			// winform의 최소화버튼을 눌렀을때의 이벤트
			if (this.WindowState == FormWindowState.Minimized)
			{
				// 윈도우의 모습을 감춘다.				
				this.Visible = false;
				// 아이콘의 모습을 감춘다.
				this.ShowIcon = false;
				// 시스템트레이의 모습을 보인다.
				notifyIcon1.Visible = true; 
				}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (lbl_FileChoice.Text.Trim() == "")
			{
				MessageBox.Show("장비 설정 파일을 선택하시기 바랍니다.");
				return;
			}
			else
			{
				// 초기화
				lblTmr.Text = "0";
				tmr = 0;
				Schedule_Timer.Enabled = true;
			}
		}
	}
}