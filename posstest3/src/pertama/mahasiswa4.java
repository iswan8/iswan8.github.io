
package pertama;

public class mahasiswa4 extends mahasiswa2 {
    
    private String AsalMhs;
    private String SekolahMhs;

    public mahasiswa4(String NamaMhs, String AsalMhs, String Prodi, int Nim, String SekolahMhs){
        super(NamaMhs, Prodi, Nim);
        this.AsalMhs = AsalMhs;
        this.SekolahMhs = SekolahMhs;
    }

    public String getAsalMhs() {
        return AsalMhs;
    }

    public String getSekolahMhs() {
        return SekolahMhs;
    }

    public void setAsalMhs(String AsalMhs) {
        this.AsalMhs = AsalMhs;
    }

    public void setSekolahMhs(String SekolahMhs) {
        this.SekolahMhs = SekolahMhs;
    }

   
}
