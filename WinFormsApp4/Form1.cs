namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        int playerY = 150;
        int aiY = 150;

        int ballY = 150;
        int ballX = 200;

        int ballSpeedX = 4;
        int ballSpeedY = 3;

        int playerScore = 0;
        int aiScore = 0;

        bool moveUp, moveDown;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            if (moveUp && playerY > 6)
                playerY -= 6;
            if (moveDown && playerY < this.ClientSize.Height - 80)
                playerY += 6;

            if (aiY + 40 < ballY) aiY += 2;
            if (aiY + 40 > ballY) aiY -= 2;

            if (aiY < 0) aiY = 0;
            if (aiY > this.ClientSize.Height - 80)
                aiY = this.ClientSize.Height - 80;

            ballX += ballSpeedX;
            ballY += ballSpeedY;

            if (ballY <= 0 || ballY >= this.ClientSize.Height - 10)
                ballSpeedY *= -1;

            Rectangle playerRect = new Rectangle(10, playerY, 10, 80);
            Rectangle ballRect = new Rectangle(ballX, ballY, 10, 10);

            if (playerRect.IntersectsWith(ballRect))
                ballSpeedX = Math.Abs(ballSpeedX);

            Rectangle aiRect = new Rectangle(this.ClientSize.Width - 20, aiY, 10, 80);

            if (aiRect.IntersectsWith(ballRect))
                ballSpeedX = -Math.Abs(ballSpeedX);

            if (ballX < 0)
            {
                aiScore++;
                ResetBall();
            }

            if (ballX > this.ClientSize.Width)
            {
                playerScore++;
                ResetBall();
            }
            Invalidate();



        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.White, 10, playerY, 10, 80);
            g.FillRectangle(Brushes.White, this.ClientSize.Width - 20, aiY, 10, 80);

            g.FillEllipse(Brushes.White, ballX, ballY, 10, 10);

            g.DrawString($"Gracz: {playerScore}", new Font("Arial", 12), Brushes.White, 50, 10);
            g.DrawString($"AI: {aiScore}", new Font("Arial", 12), Brushes.White, 400, 10);
        }

        private void ResetBall()
        {
            ballX = this.ClientSize.Width / 2;
            ballY = this.ClientSize.Height / 2;

            ballSpeedX *= -1;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                moveUp = false;
            if (e.KeyCode == Keys.Down)
                moveDown = false;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
                moveUp = true;
            if (e.KeyCode == Keys.Down)
                moveDown = true;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
