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

namespace Juego_Memoria_JL
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        String[] lista_animal = new string[16];
        String[] verificar = new string[2];
        Button[] g_boton = new Button[2];
        int puntos = 0, cont =0;
        Boolean v_empezar = false;
        




        public MainWindow()
        {
            InitializeComponent();
        }

        public void funcion_boton_empezar(object sender, RoutedEventArgs e)
        {
            //FUCION PARA UBICAR CADA ANIMAL EN UNA POSICION DE LA LISTA 

            Random rnd = new Random();   

            //INICIALIZACION DE LOS BOTONES Y LA LISTA
            funcion_inic_list();
            funcion_inic_boton();

            //AÑADIR ANIMALES A UN VECTOR          
            string[] l_animal = new string[16];
            l_animal[0] = "pez ";
            l_animal[1] = "gato ";
            l_animal[2] = "perro ";
            l_animal[3] = "suricato ";
            l_animal[4] = "abubillo ";
            l_animal[5] = "leon ";
            l_animal[6] = "impala ";
            l_animal[7] = "panda ";
            l_animal[8] = "pez ";
            l_animal[9] = "gato ";
            l_animal[10] = "perro ";
            l_animal[11] = "suricato ";
            l_animal[12] = "abubillo ";
            l_animal[13] = "leon ";
            l_animal[14] = "impala ";
            l_animal[15] = "panda ";

            //RANDOMIZAR LA LISTA 
            List <int> randomNumbers = Enumerable.Range(0, 16).OrderBy(x => rnd.Next()).Take(16).ToList();


            //GUARDARLA EN UNA LISTA 
            for(int i = 0; i<=15; i++){
                lista_animal[i] = l_animal[randomNumbers[i]];
            }

          
            //INICIALIZACION DE PUNTOS
            puntos = 0;
            Text_Puntos.Text = string.Join("", puntos);

            v_empezar = true;

            
        }

        



        public void funcion_inic_list()
        {
            //FUNCION PARA INICIALIZAR LISTA DE ANIMALES
            for (int i = 0; i <= 15; i++)
            {
                
                lista_animal[i] = "";
            }
        }


        private async void funcion_boton_memoria(object sender, RoutedEventArgs e)
        {
            //FUNCION PARA COMPARAR BOTONES
            int boton = 0;
            string s_b = "";
            
            if (v_empezar == true)
            {
                if (cont == 0)
                {

                    s_b = ((Button)sender).Name.Substring(6);
                    boton = Convert.ToInt32(s_b);

                    ((Button)sender).Content = lista_animal[boton];
                    verificar[0] = lista_animal[boton];
                    g_boton[0] = ((Button)sender);

                    cont++;

                }
                else if (cont == 1)
                {

                    g_boton[1] = ((Button)sender);

                    if (g_boton[1] != g_boton[0])
                    {
                        s_b = ((Button)sender).Name.Substring(6);
                        boton = Convert.ToInt32(s_b);
                        ((Button)sender).Content = lista_animal[boton];
                        verificar[1] = lista_animal[boton];
                        cont = 2;

                        await Task.Delay(750);

                        funcion_verificar();

                    }


                }
            }
                
        }



        public void funcion_verificar()
        {
            //FUNCION VERIFICAR LOS DOS BOTONES PULSADOS
            if(verificar[0] == verificar[1])
            {   
                g_boton[0].Opacity = 0;
                g_boton[1].Opacity = 0;
                funcion_suma_puntos();
            }
            else {
                
                g_boton[0].Content = "";
                g_boton[1].Content = "";
            }

            cont = 0;
        }

        public void funcion_suma_puntos()
        {
            //FUNCION DE SUMA DE PUNTOS 
            puntos += 10;
            Text_Puntos.Text = string.Join("Puntos: ", puntos);

        }

        public void funcion_inic_boton()
        {

            //FUNCION PARA INICIALIZAR BOTONES
            Boton_0.Opacity = 1;
            Boton_1.Opacity = 1;
            Boton_2.Opacity = 1;
            Boton_3.Opacity = 1;
            Boton_4.Opacity = 1;
            Boton_5.Opacity = 1;
            Boton_6.Opacity = 1;
            Boton_7.Opacity = 1;
            Boton_8.Opacity = 1;
            Boton_9.Opacity = 1;
            Boton_10.Opacity = 1;
            Boton_11.Opacity = 1;
            Boton_12.Opacity = 1;
            Boton_13.Opacity = 1;
            Boton_14.Opacity = 1;
            Boton_15.Opacity = 1;


            Boton_0.Content = "";
            Boton_1.Content = "";
            Boton_2.Content = "";
            Boton_3.Content = "";
            Boton_4.Content = "";
            Boton_5.Content = "";
            Boton_6.Content = "";
            Boton_7.Content = "";
            Boton_8.Content = "";
            Boton_9.Content = "";
            Boton_10.Content = "";
            Boton_11.Content = "";
            Boton_12.Content = "";
            Boton_13.Content = "";
            Boton_14.Content = "";
            Boton_15.Content = "";


        }
    }

}
