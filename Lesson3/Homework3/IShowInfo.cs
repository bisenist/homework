using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal interface IShowInfo
    {
        public void ShowInfo();
    }
    /* искренне не понимаю смысл интерфейсов, если у каждого класса все равно своя реализация, но решила сделать
    а если бы сделала "специальность" в докторе и засунула туда реализацию, не пришлось бы дублировать в каждом следующем классе?
    боюсь проверять и трогать программу, сломаю еще */
}
