# 🚗 Autószerelő Műhely Webes Alkalmazás

Ez a projekt egy fiktív autószerelő műhely számára készült webes alkalmazás, amely a műhelyben végzett munkák és ügyfelek kezelésére szolgál.

## 🎯 Projekt célja

Az alkalmazás lehetővé teszi az autószerelő műhely számára az ügyfelek és az általuk megrendelt munkák nyilvántartását, nyomon követését és kezelését egy webes felületen keresztül. Az alkalmazás tartalmaz egy **ASP.NET Core Web API** backendet és egy **Blazor WebAssembly** alapú frontend felületet (Kezdetleges).

## ✨ Főbb funkciók

- **Ügyfélkezelés:** Ügyfelek hozzáadása, szerkesztése, törlése és kilistázása.
- **Munkakezelés:** Különböző autószerelői munkák nyilvántartása CRUD (létrehozás, olvasás, módosítás, törlés) műveletekkel.
- **Ügyfélhez kapcsolódó munkák listázása:** Az adott ügyfélhez tartozó munkák könnyű megtekintése.
- **Munkaóra becslés:** Az egyes munkák időigényének kiszámítása előre meghatározott képletek alapján.

## 📐 Munkaóra becslés

A munkaóra becslés három tényező alapján történik:

- **Munka kategóriája:** Karosszéria, motor, futómű, fékberendezés.
- **Gépjármű életkora:** Az autó gyártási éve alapján.
- **Hiba súlyossága:** 1-10 skálán értékelve.

## 🛠️ Technológia és eszközök
- **Backend:** ASP.NET Core Web API (.NET 8)
- **Frontend**: Blazor WebAssembly
- **Adatbázis**: Entity Framework Core
- **Tesztelés**: Unit tesztek a Web API service-ekre

## 📂 Projekt Struktúra

```plaintext
autoszerelo-muhely/
│
├── CarMechanic.Shared/     # Megosztott modellek
│   └── Models/             # Adatmodellek
│
├── CarMechanic.Test/       # Unit tesztek
│
├── CarMechanic.UI/         # Frontend projekt (Blazor WebAssembly)
│   ├── Pages/              # Oldalak és nézetek
│   ├── Components/         # Újrafelhasználható komponensek
│   ├── Services/           # HTTP hívások API-val
│   └── Program.cs          # Blazor belépési pontja
│
└── CarMechanic/            # Backend projekt (ASP.NET Core Web API)
    ├── Controllers/        # API végpontok
    ├── Services/           # Üzleti logika
    └── Program.cs          # Alkalmazás belépési pontja




