
package ppostest4;


public class nilai {
    private String nama;
    private String nim;
    private int nilai;

    public nilai(String nama, String nim, int nilai) {
        this.nama = nama;
        this.nim = nim;
        this.nilai = nilai;
    }

    public String getNama() {
        return nama;
    }

    public String getNIM() {
        return nim;
    }

    public int getNilai() {
        return nilai;
    }

    public void display() {
        System.out.println("Nama: " + nama);
        System.out.println("NIM: " + nim);
        System.out.println("Nilai: " + nilai);
    }

    public void display(String message) {
        System.out.println(message + " " + nama + " (" + nim + ")");
    }

    public static void main(String[] args) {
        nilai mahasiswa1 = new nilai("John Doe", "12345", 90);
        mahasiswa1.display(); // memanggil method display tanpa parameter
        mahasiswa1.display("Nilai dari mahasiswa"); // memanggil method display dengan parameter
    }
}

class TranskripNilaiBaru extends nilai {
    private String semester;

    public TranskripNilaiBaru(String nama, String nim, int nilai, String semester) {
        super(nama, nim, nilai);
        this.semester = semester;
    }

    public String getSemester() {
        return semester;
    }

    public void display() {
        super.display();
        System.out.println("Semester: " + semester);
    }

   
    
}
