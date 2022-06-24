namespace AsyncAwaitDemo
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

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CountChar);
            task.Start();
            label1.Text = "Processing file... please wait...";
            int count =await task;
            label1.Text = "Total characters = " + count.ToString();
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