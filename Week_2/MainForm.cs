using System.Xml.Serialization;

namespace Week_2
{
    public partial class MainForm : Form
    {

        Random rnd = new();

        List<string> icons = new List<string>()
        {
            "ц","ц","e","e","й","й","ь","ь",
            "м","м","т","т","z","z","-","-"
        };

        Label firstClick, secondClick;




        public MainForm()
        {
            InitializeComponent();
            AssignIconsToSqares();
        }

        private void AssignIconsToSqares()
        {
            Label label;

            int randomNumber;

            for (int i = 0; i < TLP.Controls.Count; i++)
            {
                if (TLP.Controls[i] is Label)
                {
                    label = (Label)TLP.Controls[i];
                }
                else
                {
                    continue;
                }

                randomNumber = rnd.Next(0, icons.Count);
                label.Text = icons[randomNumber];


                icons.RemoveAt(randomNumber);
            }

        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (firstClick != null && secondClick != null)
            {
                return;
            }

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
            {
                return;
            }

            if (clickedLabel.ForeColor == Color.LightCoral)
            {
                return;
            }

            if (firstClick == null)
            {
                firstClick = clickedLabel;
                firstClick.ForeColor = Color.LightCoral;
                return;
            }

            secondClick = clickedLabel;
            secondClick.ForeColor = Color.LightCoral;

            CheckForWinner();

            if (firstClick.Text == secondClick.Text)
            {
                firstClick = null;
                secondClick = null;
            }
            else
            {
                Timer.Start();
            }
        }

        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < TLP.Controls.Count; i++)
            {
                label = TLP.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                {
                    return;
                }
            }
            MessageBox.Show("’орош");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer.Stop();

            firstClick.ForeColor = firstClick.BackColor;
            secondClick.ForeColor = secondClick.BackColor;

            firstClick = null;
            secondClick = null;
        }
    }
}