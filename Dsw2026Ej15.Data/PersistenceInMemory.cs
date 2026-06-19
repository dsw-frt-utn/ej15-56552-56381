using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Data;

public class PersistenceInMemory : IPersistence
{
    private readonly List<Doctor> _doctors = new();
    private readonly List<Speciality> _specialities;

    public PersistenceInMemory()
    {
        _specialities = LoadSpecialities();
    }

    private List<Speciality> LoadSpecialities()
    {
        var json = File.ReadAllText("specialities.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<List<Speciality>>(json, options)
               ?? new List<Speciality>();
    }

    public IEnumerable<Speciality> GetAllSpecialities()
        => _specialities.ToList();

    public Speciality? GetSpecialityById(Guid id)
        => _specialities.FirstOrDefault(s => s.Id == id);

    public void AddDoctor(Doctor doctor)
        => _doctors.Add(doctor);

    public IEnumerable<Doctor> GetAllDoctors()
        => _doctors.ToList();

    public IEnumerable<Doctor> GetActiveDoctors()
        => _doctors.Where(d => d.IsActive).ToList();

    public Doctor? GetDoctorById(Guid id)
        => _doctors.FirstOrDefault(d => d.Id == id);

    public Doctor? GetActiveDoctorById(Guid id)
        => _doctors.FirstOrDefault(d => d.Id == id && d.IsActive);

    public void UpdateDoctor(Doctor doctor)
    {
        var existing = _doctors.FirstOrDefault(d => d.Id == doctor.Id);

        if (existing is not null)
        {
            existing.Name = doctor.Name;
            existing.LicenseNumber = doctor.LicenseNumber;
            existing.Speciality = doctor.Speciality;
        }
    }

    public void DeactivateDoctor(Guid id)
    {
        var doctor = _doctors.FirstOrDefault(d => d.Id == id);

        if (doctor is not null)
            doctor.IsActive = false;
    }

    public void RemoveDoctor(Guid id)
    {
        var doctor = _doctors.FirstOrDefault(d => d.Id == id);

        if (doctor is not null)
            _doctors.Remove(doctor);
    }
}