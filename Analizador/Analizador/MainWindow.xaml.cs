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
            //Agregamos las columnas y las dimensionamos
            var gridView = new GridView();
            Lista.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                //Le establecemos un nombre a la columna
                Header = "Expresion",
                DisplayMemberBinding = new Binding("Expresion"),
                Width = 190

            });
            gridView.Columns.Add(new GridViewColumn
            {
                //Le establecemos un nombre a la columna
                Header = "Tipo",
                DisplayMemberBinding = new Binding("Tipo"),
                Width = 190
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Llamamos el metodo para llenar la tabla
            Tabla();
            String expresionCompleta;
            //Leemos la informacion del textbox
            expresionCompleta= expresiontxt.Text;
            //Declaramos como detectamos el cambio
            char cambio = ' ';
            //Usamos la funcion split para separar las palabras
            String[] expresiones = expresionCompleta.Split(cambio);
            for (int i = 0; i < expresiones.Length ;i++)
            {
                foreach (char letra in expresiones[i])
                {
                    int numero = 0;
                    Double decimalesmuestra = 0.0;
                    //Comprobamos si es una letra el caracter
                    if (Char.IsLetter(letra))
                    {
                       
                        char[] arraychar = expresiones[i].ToCharArray();
                        if (arraychar.Length > 1 && arraychar[0]=='Q' && arraychar[1]=='.')
                        {
                            //Agregamos el elemento a la Lista
                            Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Moneda" });
                        }
                        else
                        {
                            //Agregamos el elemento a la Lista
                            Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Palabra" });
                        }
                            break;
                    }
                    //Comprobamos si la expresion es un numero entero
                    else if (int.TryParse(expresiones[i], out numero))
                    {
                        //Agregamos el elemento a la Lista
                        Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Numero" });
                        break;
                    }
                    //Comprobamos si la expresion es un numero decimal
                    else if (Double.TryParse(expresiones[i], out decimalesmuestra))
                    {
                        //Agregamos el elemento a la Lista
                        Lista.Items.Add(new MyItem { Expresion = expresiones[i], Tipo = "Decimal" });
                        break;
                    }
                    
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            expresiontxt.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Lista.Items.Clear();
        }
    }
    public class MyItem
    {
        //Declaramos las columnas de nuestra lista
        public string Expresion { get; set; }
        public string Tipo { get; set; }
    }
}
