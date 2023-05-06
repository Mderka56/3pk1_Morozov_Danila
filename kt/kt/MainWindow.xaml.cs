using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace kt
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string filePath;
        public bool isTextChanged;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridType.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AddTextBut_Click(object sender, RoutedEventArgs e)
        {
            GridText.Visibility = Visibility.Visible;
            GridJpg.Visibility = Visibility.Hidden;
        }

        private void AddJpgBut_Click(object sender, RoutedEventArgs e)
        {
            GridText.Visibility = Visibility.Hidden;
            GridJpg.Visibility = Visibility.Visible;
        }

        private void ChangeBrushBut_Click(object sender, RoutedEventArgs e)
        {
            if (IC.EditingMode == InkCanvasEditingMode.Ink) 
                IC.EditingMode = InkCanvasEditingMode.EraseByPoint;
            else 
                IC.EditingMode = InkCanvasEditingMode.Ink;
        }

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(filePath))
        //    {
        //        SaveFileDialog saveFileDialog = new SaveFileDialog();

        //        if (saveFileDialog.ShowDialog() == true)
        //        {
        //            filePath = saveFileDialog.FileName;
        //        }
        //    }
        //    File.WriteAllText($"{filePath}.txt", TxtTb.Text);
        //    isTextChanged = false;
        //}

        //private void SaveJpgBut_Click(object sender, RoutedEventArgs e)
        //{
        //    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
        //    dlg.FileName = "savedimage";
        //    dlg.DefaultExt = ".jpg";
        //    dlg.Filter = "Image (.jpg)|*.jpg";

        //    Nullable<bool> result = dlg.ShowDialog();

        //    if (result == true)
        //    {
        //        string filename = dlg.FileName;
        //        int margin = (int)this.IC.Margin.Left;
        //        int width = (int)this.IC.ActualWidth - margin;
        //        int height = (int)this.IC.ActualHeight - margin;
        //        RenderTargetBitmap rtb =
        //        new RenderTargetBitmap(width, height, 94d, 92d, PixelFormats.Default);
        //        rtb.Render(IC);

        //        using (FileStream fs = new FileStream(filename, FileMode.Create))
        //        {
        //            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
        //            encoder.Frames.Add(BitmapFrame.Create(rtb));
        //            encoder.Save(fs);
        //        }
        //    }
        //}


        // Короче я пытался но видимо плохо пытался
        class Memento
        //вроде как управляет механизмом сохранения и восстановления состояний
        {
            public string State { get; private set; }
            public Memento(string state)
            {
                this.State = state;
            }
        }

        class Caretaker
            //хранит информацию о состоянии
        {
            public Memento Memento { get; set; }
        }

        class Originator
        {
            //вроде как хранит и выполняет все методы, сохраняет состояние и восстанавливает его
            public string State { get; set; }
            public void SetMemento(Memento memento)
            {
                State = memento.State;
            }
            public Memento CreateMemento()
            {
                return new Memento(State);
            }


            private void Button_Click_2(object sender, RoutedEventArgs e)
            {//за пределами хранителя это работает
                if (string.IsNullOrEmpty(filePath))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        filePath = saveFileDialog.FileName;
                    }
                }
                File.WriteAllText($"{filePath}.txt", TxtTb.Text);
                isTextChanged = false;
            }
            public void SaveJpgBut() //за пределами хранителя это работает
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "savedimage";
                dlg.DefaultExt = ".jpg";
                dlg.Filter = "Image (.jpg)|*.jpg";

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    string filename = dlg.FileName;
                    int margin = (int)this.IC.Margin.Left;
                    int width = (int)this.IC.ActualWidth - margin;
                    int height = (int)this.IC.ActualHeight - margin;
                    RenderTargetBitmap rtb =
                    new RenderTargetBitmap(width, height, 94d, 92d, PixelFormats.Default);
                    rtb.Render(IC);

                    using (FileStream fs = new FileStream(filename, FileMode.Create))
                    {
                        BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(rtb));
                        encoder.Save(fs);
                    }
                }
            }
        }

    }




}
