using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Domain.Interfaces;

public interface IPersistence
{
    IEnumerable<Speciality> GetAllSpecialities();
    Speciality? GetSpecialityById(Guid id);

    void AddDoctor(Doctor doctor);
    IEnumerable<Doctor> GetAllDoctors();
    IEnumerable<Doctor> GetActiveDoctors();
    Doctor? GetDoctorById(Guid id);
    Doctor? GetActiveDoctorById(Guid id);
    void UpdateDoctor(Doctor doctor);
    void DeactivateDoctor(Guid id);
    void RemoveDoctor(Guid id);
}