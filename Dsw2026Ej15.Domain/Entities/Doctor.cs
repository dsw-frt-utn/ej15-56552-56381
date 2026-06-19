using Dsw2026Ej15.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities;

public class Doctor : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Speciality Speciality { get; set; } = null!;

    public Doctor() { }

    public Doctor(string name, string licenseNumber, Speciality speciality)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("El nombre del médico es requerido.");

        if (string.IsNullOrWhiteSpace(licenseNumber))
            throw new ValidationException("El número de matrícula es requerido.");

        Name = name;
        LicenseNumber = licenseNumber;
        Speciality = speciality;
        IsActive = true;
    }
}