using API.interfaces;
using file_service;
using Microsoft.AspNetCore.Mvc;
using models;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : ControllerBase
{

  private MyFileService _file = new MyFileService("volunteers.json", "files");

  [HttpGet("{day}")]
  public List<Volunteer> GetByDay(int day)
  {
    //  Mylogger.WriteMessage($"controller: {nameof(PizzaController)} action: {nameof(GetById)} id:{id}");
    //return Ip.GetById(id);
    List<Volunteer> volunteers = this._file.Gets<Volunteer>();
    List<Volunteer> volPerDay = new List<Volunteer>();
    for (int i = 0; i < volunteers.Count; i++)
    {
      if (volunteers[i].Days[day] == true)

        volPerDay.Add(volunteers[i]);
    }
    Volunteer v=new Volunteer();
    v.Name="---";
    volPerDay.Add(v);//empty volunteer---
    return volPerDay;
  }
  [HttpGet("byId")]
  public Volunteer GetById(int id)
  {
    //  Mylogger.WriteMessage($"controller: {nameof(PizzaController)} action: {nameof(GetById)} id:{id}");
    //return Ip.GetById(id);
    List<Volunteer> volunteers = this._file.Gets<Volunteer>();
    
    for (int i = 0; i < volunteers.Count; i++)
    {
      if (volunteers[i].Id == id)

        return volunteers[i];
    }

    return null;
  }
  [HttpGet]
  public List<Volunteer> Get()
  {
    List<Volunteer> volunteers = this._file.Gets<Volunteer>();
    return volunteers;
  }


  [HttpPut("update")]
  public List<Volunteer> Update(Volunteer vol)
  {

    List<Volunteer> volunteers = this._file.Gets<Volunteer>();
    for(int i=0; i<volunteers.Count; i++)
    {
      if (volunteers[i].Id == vol.Id)
      {
        volunteers[i] = vol;
        _file.Update<Volunteer>(volunteers);
        List<Volunteer> lsvolunteers = this._file.Gets<Volunteer>();
        return lsvolunteers;
      }

    }
    return null;

  }
  [HttpPost]
  public void AddVolunteer(Volunteer vol)
  {
    _file.AddItem(vol);
    return;
  }
}