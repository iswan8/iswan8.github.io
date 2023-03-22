 
package pertama;
 
public class mahasiswa3 extends mahasiswa2{
   private String UnivMhs;

    public mahasiswa3(String NamaMhs, String UnivMhs, String Prodi, int Nim){
        super(NamaMhs, Prodi, Nim);
        this.UnivMhs = UnivMhs;
    }

    public String getUnivMhs() {
        return UnivMhs;
    }

    public void setUnivMhs(String UnivMhs) {
        this.UnivMhs = UnivMhs;
    }

    
            
    
}
