using Dsw2026Ej15.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities;

public class Speciality : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public Speciality() { }

    public Speciality(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("El nombre de la especialidad es requerido.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ValidationException("La descripción de la especialidad es requerida.");

        Name = name;
        Description = description;
    }
}