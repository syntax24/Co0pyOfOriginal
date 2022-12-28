using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;

namespace Company.Domain.MandatoryHoursAgg
{
    public class MandatoryHours : EntityBase
    {
        public MandatoryHours(int year, double farvardin, double ordibehesht, double khordad, double tir, double mordad, double shahrivar, double mehr, double aban, double azar, double dey, double bahman, double esfand)
        {
            Year = year;
            Farvardin = farvardin;
            Ordibehesht = ordibehesht;
            Khordad = khordad;
            Tir = tir;
            Mordad = mordad;
            Shahrivar = shahrivar;
            Mehr = mehr;
            Aban = aban;
            Azar = azar;
            Dey = dey;
            Bahman = bahman;
            Esfand = esfand;
        }

        public int Year { get; private set; }
        public double Farvardin { get; private set; }
        public double Ordibehesht { get; private set; }
        public double Khordad { get; private set; }
        public double Tir { get; private set; }
        public double Mordad { get; private set; }
        public double Shahrivar { get; private set; }
        public double Mehr { get; private set; }
        public double Aban { get; private set; }
        public double Azar { get; private set; }
        public double Dey { get; private set; }
        public double Bahman { get; private set; }
        public double Esfand { get; private set; }
        public List<Contract> Contracts { get; set; }

        public MandatoryHours()
        {
            Contracts = new List<Contract>();
        }

        public void Edit(int year, double farvardin, double ordibehesht, double khordad, double tir, double mordad, double shahrivar, double mehr, double aban, double azar, double dey, double bahman, double esfand)
        {
            Year = year;
            Farvardin = farvardin;
            Ordibehesht = ordibehesht;
            Khordad = khordad;
            Tir = tir;
            Mordad = mordad;
            Shahrivar = shahrivar;
            Mehr = mehr;
            Aban = aban;
            Azar = azar;
            Dey = dey;
            Bahman = bahman;
            Esfand = esfand;
        }
    }
}
