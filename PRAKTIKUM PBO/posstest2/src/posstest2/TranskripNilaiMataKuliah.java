package posstest2;

import java.util.ArrayList;

public class TranskripNilaiMataKuliah {

    private String namaMHS;
    private String nim;
    private String programStudi;
    private ArrayList<matakuliah> listMataKuliah;

    public TranskripNilaiMataKuliah(String namaMHS, String nim, String programStudi) {
        this.namaMHS = namaMHS;
        this.nim = nim;
        this.programStudi = programStudi;
        this.listMataKuliah = new ArrayList<>();
    }

    public TranskripNilaiMataKuliah(String namaMHS, String nim, String programStudi, ArrayList<matakuliah> listMataKuliah) {
        this.namaMHS = namaMHS;
        this.nim = nim;
        this.programStudi = programStudi;
        this.listMataKuliah = listMataKuliah;
    }

    public void insert(String kodeMK, String namaMK, int sks, String nilaiHuruf) {
        matakuliah mk = new matakuliah(kodeMK, namaMK, sks, nilaiHuruf);
        listMataKuliah.add(mk);
    }

    public boolean update(int id, String kodeMK, String namaMK, int sks, String nilaiHuruf) {
        boolean status = false;

        if (id >= 0 && id < listMataKuliah.size()) {
            matakuliah mk = new matakuliah(kodeMK, namaMK, sks, nilaiHuruf);
            listMataKuliah.set(id, mk);
            status = true;
        }
        return status;
    }

    public boolean delete(int id) {
        boolean status = false;

        if (id >= 0 && id < listMataKuliah.size()) {
            listMataKuliah.remove(id);
            status = true;
        }
        return status;
    }

    public void cetak() {
        System.out.println("==========================================================================================");
        System.out.println("                                      TRANSKRIP                        ");
        System.out.println("==========================================================================================");
        System.out.println("Nama          : " + namaMHS);
        System.out.println("NIM           : " + nim);
        System.out.println("Program Studi : " + programStudi);
        System.out.println("------------------------------------------------------------------------------------------");
        System.out.printf("| %-3.3s | %-10s | %-50.50s | %3.3s | %5.5s |%n", "ID", "KODE", "Matakuliah", "SKS", "NILAI");
        System.out.println("------------------------------------------------------------------------------------------");
        if (!listMataKuliah.isEmpty()) {
            int sksTotal = 0;
            double nilaiTotal = 0;
            for (int i = 0; i < listMataKuliah.size(); i++) {
                int id = 1 + i;
                System.out.printf("| %3d ", id);
                listMataKuliah.get(i).cetak();
                System.out.println();
                sksTotal += listMataKuliah.get(i).getSks();
                nilaiTotal += listMataKuliah.get(i).sksKaliNilai();
            }
            System.out.println("------------------------------------------------------------------------------------------");
            System.out.println("SKS : " + sksTotal);
            double ipk = nilaiTotal / sksTotal;
            System.out.printf("%s%.2f%n", "IPK : ", ipk);
        } else {
            System.out.println("LIST MATA KULIAH KOSONG");
        }
        System.out.println("------------------------------------------------------------------------------------------");
    }

    public String getNamaMHS() {
        return namaMHS;
    }

    public void setNamaMHS(String namaMHS) {
        this.namaMHS = namaMHS;
    }

    public String getNim() {
        return nim;
    }

    public void setNim(String nim) {
        this.nim = nim;
    }

    public String getProgramStudi() {
        return programStudi;
    }

    public void setProgramStudi(String programStudi) {
        this.programStudi = programStudi;
    }

    public ArrayList<matakuliah> getListMataKuliah() {
        return listMataKuliah;
    }

    public void setListMataKuliah(ArrayList<matakuliah> listMataKuliah) {
        this.listMataKuliah = listMataKuliah;
    }

}
