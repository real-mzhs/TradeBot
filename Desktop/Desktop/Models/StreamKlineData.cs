using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    internal class StreamKlineData
    {
        public long t { get; set; }  // Время начала свечи
        public long T { get; set; }  // Время окончания свечи
        public string s { get; set; }  // Торговая пара
        public string i { get; set; }  // Интервал свечи
        public decimal f { get; set; }  // Первый ID сделки
        public decimal L { get; set; }  // Последний ID сделки
        public decimal o { get; set; }  // Цена открытия
        public decimal c { get; set; }  // Цена закрытия
        public decimal h { get; set; }  // Самая высокая цена
        public decimal l { get; set; }  // Самая низкая цена
        public decimal v { get; set; }  // Объем базового актива
        public int n { get; set; }  // Количество сделок
        public bool x { get; set; }  // Закрыта ли свеча?
        public decimal q { get; set; }  // Объем котируемого актива
        public decimal V { get; set; }  // Объем базового актива покупателя
        public decimal Q { get; set; }  // Объем котируемого актива покупателя
        public string B { get; set; }  // Проигнорировать
    }
}
