using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP8
{
    struct Health
    {
        private int value;
        public int Value
        {
            get
            {
                return value;
            }
            set 
            {
                if ((-1 < value) && (value < 101))
                {
                    this.value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public Health(int value)
        {
            this.value = value;
        }

        public void Increase(int difference)
        { this.Value += difference; }

        public void Decrease(int difference)
        { this.Value -= difference; }
    }
    
    class Gamer : ObjectOfGame
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Health health { get; private set; }
    }
}
