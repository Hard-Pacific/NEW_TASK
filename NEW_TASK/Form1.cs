using System;

namespace NEW_TASK
{
    public partial class Form1 : Form
    {
        private int N = 10; // ����������� ����

        private Button[,] buttons; // ������ ������
        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
        }
        private void InitializeButtons()
        {
            buttons = new Button[N, N];

            int buttonSize = ClientSize.Width / N;
            int[] numbers = new int[N * N]; // ������ �����

            // ��������� ������ ����� �� 0 �� N^2/2 - 1
            for (int i = 0; i < N * N; i += 2)
            {
                numbers[i] = i / 2;
                numbers[i + 1] = i / 2;
            }
            Random random = new Random(); // �������� ������� ��� ��������� ��������� �����

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(buttonSize, buttonSize);
                    button.Location = new Point(i * buttonSize, j * buttonSize);
                    if (button.BackColor == Color.White)
                    {
                        button.BackColor = Color.White;
                    }
                    if (button.BackColor == Color.White)
                    {
                        button.BackColor = Color.Red;
                    }
                    int index = random.Next(numbers.Length);
                    button.Text = numbers[index].ToString();
                    numbers = numbers.Where((val, idx) => idx != index).ToArray();
                    button.Click += Button_Click;
                    buttons[i, j] = button;
                    Controls.Add(button);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Red;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <N; j++)
                {
                    if (buttons[i, j].BackColor == button.BackColor && buttons[i, j].Text == button.Text)
                    {
                        // ������������ ��� ������
                        button.Enabled = false;
                        buttons[i, j].Enabled = false;
                        button.BackColor = Color.Green;
                    }
                }
            }
        }

    }
}