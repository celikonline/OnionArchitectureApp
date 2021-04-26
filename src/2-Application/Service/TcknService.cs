using System;
using System.Collections.Generic;
using System.Text;

namespace Efactura.Application.Service
{
    public class TcknService : ITcknService
    {
        public String GetUniqueNewTckn()
        {
            String tckn;
            do
            {
                tckn = GenerateRundomTckn();

            } while (!IsValidTckn(tckn));

            return tckn;
        }

        private string GenerateRundomTckn()
        {
            Random randomNumber = new Random();

            String tckn = "";
            for (int i = 0; i < 9; i++)
                tckn += randomNumber.Next(1, 10);

            return CalculateTckn(tckn);

        }

        private String CalculateTckn(String tckn)
        {
            string _tckn = tckn;
            // 1) 1, 3, 5, 7 ve 9. sıradaki rakamın toplamının 7 katı 
            int tekBasamaklar = 0;
            for (int i = 0; i < 9; i += 2)
                tekBasamaklar += int.Parse(_tckn.Substring(i, 1)) * 7;

            // 2) 2, 4, 6 ve 8.rakamın toplamının 9 katını topla
            int ciftBasamaklar = 0;
            for (int i = 1; i < 9; i += 2)
                ciftBasamaklar += int.Parse(_tckn.Substring(i, 1)) * 9;

            // 3) Çıkan sonucun birler basamağı 10. rakamı veriyor
            int onuncuBasamak = (tekBasamaklar + ciftBasamaklar) % 10;

            // 4) Hesaplanan 10. basamağı, 9 basamağı oluşturan Tc kimlik numarasına ekle
            _tckn += onuncuBasamak;

            // 5) ilk 10 rakamın toplamının birler basamağı 11. rakamı veriyor
            int onBirinciBasamak = 0;
            for (int i = 0; i < 10; i++)
                onBirinciBasamak += int.Parse(_tckn.Substring(i, 1));
            onBirinciBasamak %= 10;

            // 6) Elde edilen ilk 10 ve 11. haneyi birleştirip diziye ekle
            _tckn += onBirinciBasamak;

            return _tckn;
        }


        private static bool IsValidTckn(string tckn)
        {
            bool returnvalue = false;
            if (tckn.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tckn);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }

    }
}
