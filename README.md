# Glob
Komunikator internetowy czasu rzeczywistego z szyfrowaniem end to end.
## Technologie
* WinForms
* Asp.Net Core 5
* SignalR
* .NET Core 5

## Technikalia
### 1. Rejestracja:
 1. Klient wprowadza dane i wysyła dla serwera.
 2. Serwer sprawdza, czy podany login jest unikalny.
 3. Klient generuje klucz publiczny i prywatny, którego nikomu nie udostępnia. Generowanie kluczy odbywa się algorytmem RSA.
 4. Klient przesyła serwerowi klucz publiczny.
 5. Serwer przechowuje klucz publiczny użytkownika.

### 2. Dodanie nowego kontaktu
 1. Klient prosi serwer o dodanie kontaktu z danym loginem.
 2. Serwer zwraca użytkownikowi klucz publiczny odpowiedniego kontaktu.
 3. Klient generuje klucz AES i szyfruje kluczem publicznym kontaktu, po czym wysyła serwerowi.
 4. Serwer zapisuje dane z kroku 3. aż do zalogowania się kontaktu.
 5. Kontakt po zalogowaniu odbiera od serwera informację, że dodano nowy kontakt i deszyfruje swoim kluczem prywatnym RSA klucz szyfrujący AES z kroku 3. Po czym zapisuje go lokalnie na swoim urządzeniu.
 6. Serwer kasuje dane z kroku 3.

### 3. Wymiana wiadomości
 1. Każda konwersacja jest szyfrowana osobnym kluczem AES, który jest przechowywany lokalnie tylko na urządzeniach komunikujących się osób.
 2. Każda wiadomość jest szyfrowana i deszyfrowana kluczem AES, który został ustalony przez jednego z komunikujących się i przesłany w zaszyfrowanej postaci, używając klucza publicznego RSA drugiego uczestnika rozmowy.
 3. Każda wiadomość jest podpisana kluczem publicznym RSA.

### 4. Algorytmy
 * Implementacja algorytmu RSA używanego w aplikacji jest dostarczona przez *RSACryptoServiceProvider* z biblioteki *System.Security.Cryptography* .NET Core 5. Działa na kluczu o długości 2048.
 * Implementacja algorytmu AES używanego w aplikacji jest dostarczona przez *Aes* z biblioteki *System.Security.Cryptography* .NET Core 5. Działa na kluczu o długości 256.
 * Podpis cyfrowy odbywa się za pomocą wspomnianego wcześniej algorytmu RSA z funkcją hashującą SHA256.

### Inne
 * Wszystkie klucze, które są przechowywane lokalnie są zapisywane w pliku properties, który znajduje się w folderze aplikacji.
 * Nie podpisane lub źle podpisane wiadomości są ignorowane przez serwer.
 * Komunikacja między użytkownikami jest czasu rzeczywistego i odbywa się za pośrednictwem **SignalR**.
 * Serwer przechowuje tylko loginy, dane profilowe, hashe haseł, klucze publiczne i zaszyfrowane algorytmem AES wiadomości.
 * Użytkownik nie może zmienić swojego klucza publicznego. 
