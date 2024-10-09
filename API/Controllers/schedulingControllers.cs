using API.interfaces;
using file_service;
using Microsoft.AspNetCore.Mvc;
using models;

namespace API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SchedulingController : ControllerBase
{
  private MyFileService _file = new MyFileService("scheduling.json", "files");

  [HttpGet]
  public List<int> Get()
  {
    List<int> schedul =this._file.Gets<int>();
    return schedul;
  }
    

    [HttpPut("byDay")]
  public List<int> UpdateByDay(int vol,int day)
  {

    List<int> volunteers = this._file.Gets<int>();
    
        volunteers[day] = vol;
        _file.Update<int>(volunteers);
        List<int> lsvolunteers = this._file.Gets<int>();
       return lsvolunteers;
      
  }

[HttpPut]
  public List<int> UpdateScheduling(List<int> volunteers)
  {

        _file.Update<int>(volunteers);
        List<int> lsvolunteers = this._file.Gets<int>();
        return lsvolunteers;
      }

//     [HttpPut]
//   public Scheduling UpdateScheduling(Scheduling sched)
//   {

//         _file.UpdatObj<Scheduling>(sched);
//         Scheduling scheduling = this._file.GetObj<Scheduling>();
//         return scheduling;
//       }

  

}
