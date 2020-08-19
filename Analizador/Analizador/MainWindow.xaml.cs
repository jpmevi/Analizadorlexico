using System;
using System.Collections.Generic;
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

namespace Analizador
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Tabla()
        {
            // Add columns
            var gridView = new GridView();
            Lista.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Expresion",
                DisplayMemberBinding = new Binding("Expresion"),
                Width = 190

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Tipo",
                DisplayMemberBinding = new Binding("Tipo"),
                Width = 190
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tabla();
            String expresionCompleta;
            expresionCompleta= expresiontxt.Text;
            char delimitador = ' ';
            String[] expresiones = expresionCompleta.Split(delimitador);
            String[] palabras = new String[20];
            String[] enteros = new String[20];
            String[] decimales = new String[20];
            for (int i = 0; i < expresiones.Length ;i++)
            {
                foreach (char letra in expresiones[i])
                {
                    int numero = 0;
                    Double decimalesmuestra = 0.0;
                    if (Char.IsLetter(letra))
                    {
                       
                        char[] arraychar = expresiones[i].ToCharArray();
                        if (arraychar.Length > 1 && arraychar[0]=='Q' && arraychar[1]=='.')
                        {
                            MessageBox.Show(expresiones[i] + " es moneda");
                            Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Moneda" });
                        }
                        else
                        {
                            MessageBox.Show(expresiones[i] + " es palabra");
                            Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Palabra" });
                        }
                            break;
                    }
                    else if (int.TryParse(expresiones[i], out numero))
                    {
                        MessageBox.Show(expresiones[i] + " es numero");
                        Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Numero" });
                        break;
                    }
                    else if (Double.TryParse(expresiones[i], out decimalesmuestra))
                    {
                        MessageBox.Show(expresiones[i] + " es decimal");
                        Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Decimal" });
                        break;
                    }
                    
                }
            }
        }
    }
    public class MyItem
    {
        public string Expresion { get; set; }
        public string Tipo { get; set; }
    }
}
