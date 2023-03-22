package pertama;

public class mahasiswa2 {
    protected String NamaMhs;
    protected String Prodi;
    protected int Nim;
   
    public mahasiswa2(String NamaMhs, String Prodi, int Nim){
        this.NamaMhs = NamaMhs;
        this.Prodi = Prodi;
        this.Nim = Nim;
    }

    public String getNamaMhs() {
        return NamaMhs;
    }

    public String getProdi() {
        return Prodi;
    }

    public int getNim() {
        return Nim;
    }

    public void setNamaMhs(String NamaMhs) {
        this.NamaMhs = NamaMhs;
    }

    public void setProdik(String Prodi ) {
        this.Prodi = Prodi;
    }

    public void setNim(int Nim) {
        this.Nim = Nim;
    }

    
}
