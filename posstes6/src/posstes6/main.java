package posstes6;

import posstes6.HitungNilai.TranskripNilai;

public class main {

    public static void main(String[] args) {
        TranskripNilai transkrip1 = new TranskripNilai("John");

        transkrip1.tambahNilai(90);
        transkrip1.tambahNilai(85);
        transkrip1.tambahNilai(78);
        transkrip1.tambahNilai(92);

        System.out.println("Nama: " + transkrip1.getNama());
        System.out.println("Nilai: " + transkrip1.getNilai());
        System.out.println("Rata-rata: " + transkrip1.hitungRataRata());
        System.out.println("Grade: " + transkrip1.hitungGrade());
    }
}
