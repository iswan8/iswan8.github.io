package posstes5;

public abstract class TanskripNilai {

    private final String nama;
    private final int nilai;

    public TanskripNilai(String nama, int nilai) {
        this.nama = nama;
        this.nilai = nilai;
    }

    public String getNama() {
        return nama;
    }

    public int getNilai() {
        return nilai;
    }

    public abstract String getNilaiHuruf();

    public static void main(String[] args) {

    }

}
