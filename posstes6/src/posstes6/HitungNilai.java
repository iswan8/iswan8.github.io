package posstes6;

import java.util.ArrayList;

interface HitungNilai {

    double hitungRataRata();

    String hitungGrade();

    public class TranskripNilai implements HitungNilai {

        private String nama;
        private ArrayList<Double> nilai;

        public TranskripNilai(String nama) {
            this.nama = nama;
            this.nilai = new ArrayList<>();

        }

        public void tambahNilai(double nilai) {
            this.nilai.add(nilai);

        }

        public double hitungRataRata() {
            if (nilai.isEmpty()) {
                return 0;
            }

            double total = 0;
            for (double n : nilai) {
                total += n;
            }
            return total / nilai.size();
        }

        public String hitungGrade() {
            double rataRata = hitungRataRata();
            if (rataRata >= 90) {
                return "A";
            } else if (rataRata >= 80) {
                return "B";
            } else if (rataRata >= 70) {
                return "C";
            } else if (rataRata >= 60) {
                return "D";
            } else {
                return "E";
            }
        }

        public String getNama() {
            return nama;
        }

        public ArrayList<Double> getNilai() {
            return nilai;
        }

       

    }
}
