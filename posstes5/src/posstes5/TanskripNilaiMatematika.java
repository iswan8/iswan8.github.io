package posstes5;

public class TanskripNilaiMatematika extends TanskripNilai {

    public TanskripNilaiMatematika(String nama, int nilai) {
        super(nama, nilai);
    }

    public String getNilaiHuruf() {
        if (getNilai() >= 90) {
            return "A";
        } else if (getNilai() >= 80) {
            return "B";
        } else if (getNilai() >= 70) {
            return "C";
        } else if (getNilai() >= 60) {
            return "D";
        } else {
            return "E";
        }
    }

}
