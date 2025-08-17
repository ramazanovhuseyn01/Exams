# 📚 Exam Management System

Bu layihə tələbələrin, müəllimlərin, dərslərin və imtahanların idarə olunmasını təmin edən *Exam Management System-dir. Sistem **ASP.NET Core Web API* üzərində qurulub və *Onion Architecture, **CQRS, **MediatR, və **Repository Pattern* prinsiplərindən istifadə edir.

---

## 🔧 Texnologiyalar
- ASP.NET Core 8 (Web API)  
- Entity Framework Core + SQL Server  
- MediatR (CQRS)  
- AutoMapper  
- Newtonsoft.Json  
- HttpClient (API çağırışları üçün)  

---

## 📂 Layihə Quruluşu
- *Domain* – Entity-lər, Base Entity
- *Application* – DTO, Service (Interface, Implementations) CQRS Command & Query handler-lar, AutoMapper profilləri  
- *Repository* – AppDbContext, EF Core əməliyyatları və Migration-lar  
- *API*

---

## 🔄 Arxitektura
- *CQRS + MediatR* – oxuma və yazma əməliyyatları ayrı handler-lar ilə idarə olunur  
- *Repository + Unit of Work* – DB əməliyyatları tranzaksiya səviyyəsində idarə olunur  

---

## 📡 Əsas API-lər

### Exam API
- GET /api/Exam/GetAll – bütün imtahanları gətirir  
- POST /api/Exam/Create – yeni imtahan əlavə edir  
- PUT /api/Exam/Edit/{id} – mövcud imtahanı yeniləyir  
- DELETE /api/Exam/Delete/{id} – imtahanı silir  

### Student API
- GET /api/Student/GetAll – bütün tələbələri gətirir  
- POST /api/Student/Create – yeni tələbə əlavə edir  
- PUT /api/Student/Edit/{id} – tələbəni yeniləyir  

### Lesson API
- GET /api/Lesson/GetAll – bütün tələbələri gətirir  
- POST /api/Lesson/Create – yeni tələbə əlavə edir  
- PUT /api/Lesson/Edit/{id} – tələbəni yeniləyir  

---

## ✅ Yekun
- Modul yanaşma (*Onion Architecture*)  
- CQRS və MediatR ilə aydın əməliyyat axını  
- Repository & Unit of Work ilə güclü DB idarəsi  
