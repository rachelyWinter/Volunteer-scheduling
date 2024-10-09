//using myAPIprojects.myModels;

namespace API.interfaces{


    public interface Ifile
    {
        
    public void setFilePath(string fileName,string filePath);
     //read from file
     public List<T> Gets<T>();
     //write to file
     public void Write(string obj);
     //update tha data in the file
     public void Update<T>(List<T> list);
     //add item to file
     public void AddItem<T>(T item);
    }
}