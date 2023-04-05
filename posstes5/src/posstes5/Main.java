package posstes5;

public class Main {

    public static void main(String[] args) {
        TanskripNilaiMatematika siswa1 = new TanskripNilaiMatematika("Ali", 85);
        TanskripNilaiMatematika siswa2 = new TanskripNilaiMatematika("Budi", 60);

        System.out.println(siswa1.getNama() + " mendapatkan nilai " + siswa1.getNilai() + " (" + siswa1.getNilaiHuruf() + ")");
        System.out.println(siswa2.getNama() + " mendapatkan nilai " + siswa2.getNilai() + " (" + siswa2.getNilaiHuruf() + ")");
    }

}
