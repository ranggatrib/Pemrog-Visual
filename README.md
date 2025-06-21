# Project Pemrograman Visual
 
## Langkah-langkah Membuat Repository dan Push ke GitHub

**1. Buat Repository di GitHub**
- Buka GitHub dan login.
- Klik tombol "+" di kanan atas, lalu pilih New repository.
- Masukkan nama repository: Pemrog-Visual.
- Pilih Public atau Private sesuai kebutuhan.
- Klik Create repository.

**2. Buat Folder Project di Lokal**
- Buka Terminal atau Command Prompt, lalu jalankan perintah berikut:
- mkdir Pemrog-Visual
- cd Pemrog-Visual
- mkdir Project
- cd Project
- echo "# Project Pemrograman Visual" > README.md
- cd ..

**3. Inisialisasi Git dan Push ke Repository**
- Buka folder Pemrog-Visual, jalankan perintah berikut di Git Bash atau Command Prompt:
- git init
- git remote add origin https://github.com/USERNAME/Pemrog-Visual.git  # Ganti USERNAME dengan username GitHub anda
- git add .
- git commit -m "Menambahka Folder Project"
- git branch -M main
- git push -u origin main
