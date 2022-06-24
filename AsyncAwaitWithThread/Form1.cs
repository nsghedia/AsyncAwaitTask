namespace AsyncAwaitWithThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            Thread thread = new Thread(() =>
            {
                count = CountChar();
                Action action = () => label1.Text = "Total characters = " + count.ToString();
                this.BeginInvoke(action);
            });
            thread.Start();
            label1.Text = "Processing file... please wait...";
            //thread.Join(); //Blocks UI
        }

        private int CountChar()
        {
            var count = 0;
            using (StreamReader streamReader = new StreamReader(@"G:\Study\Practicals\.NET Project\AsyncAwait\AsyncAwaitDemo\DemoTextFile.txt"))
            {
                string content = streamReader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }
            return count;
        }
    }
}