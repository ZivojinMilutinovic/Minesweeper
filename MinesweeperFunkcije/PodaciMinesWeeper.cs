using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojButton;
namespace MinesweeperFunkcije
{
    class PodaciMinesWeeper
    {
        private int dimenzija;
        private int brojMina;
        private int brojZastavica;
        private MyButton[] buttons;
        private static PodaciMinesWeeper instance;
        private static object syncObject=new object();
        private PodaciMinesWeeper()
        {
            dimenzija = 9;
            brojMina = 10;
            brojZastavica = 10;
            buttons = new MyButton[dimenzija * dimenzija];
        }

        public int Dimenzija { get => dimenzija; set => dimenzija = value; }
        public int BrojMina { get => brojMina; set => brojMina = value; }
        public int BrojZastavica { get => brojZastavica; set => brojZastavica = value; }
        public MyButton this[int i]
        {
            get { return buttons[i]; }
            set { buttons[i] = value; }
        }
        public static PodaciMinesWeeper Instance
        {
            get
            {
                lock(syncObject)
                {
                    if (instance == null)
                        instance = new PodaciMinesWeeper();
                }
                return instance;
            }
        }
      
    }
}
