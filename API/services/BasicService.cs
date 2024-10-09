using API.interfaces;

namespace services;

public class BasicService
{

  private Ifile _file;
 public BasicService(Ifile file)
  {
    this._file=file;
    this._file.setFilePath("myFile.json","files");
    //this.pizzas=_file.Gets<Pizza>();
  }
}
