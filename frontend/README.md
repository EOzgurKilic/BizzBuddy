# BizzBuddy Frontend (React + Vite + TypeScript)

Bu klasör tamamen yeni bir React projesidir. Backend API&apos;ye bağlanmak için gerekli başlangıç
ayarlarını içerir ve Rider içinde çalıştırmaya hazırdır.

## 1) Kurulum
1. Terminali açın (`frontend` klasöründe).
2. Bağımlılıkları indirin:
   ```bash
   npm install
   ```

## 2) Geliştirme
- Hızlı başlatma:
  ```bash
  npm run dev
  ```
- Rider Run/Debug için: *Add Configuration → npm → dev* seçin.
- Çıktıda gözüken adresi (genelde `http://localhost:5173`) tarayıcıda açın.

## 3) Backend API adresi
`frontend/.env.local` dosyası oluşturup URL&apos;i yazın:
```bash
VITE_API_BASE_URL=http://localhost:5000/api
```
Kod içinde `import.meta.env.VITE_API_BASE_URL` ile erişebilirsiniz.

## 4) Örnek istek (src/App.tsx içinde de var)
```ts
const API_URL = import.meta.env.VITE_API_BASE_URL;

fetch(`${API_URL}/health`)
  .then((res) => res.json())
  .then(console.log)
  .catch(console.error);
```

## 5) Derleme
```bash
npm run build
npm run preview  # production çıktısını yerelde görmek için
```

## 6) Yapı
- `src/main.tsx`: Uygulama girişi.
- `src/App.tsx`: Örnek ekran ve API çağrısı şablonu.
- `vite.config.ts`: Gerekirse proxy veya alias eklemek için.

Sorun yaşarsanız terminal hatasını paylaşarak devam edebilirsiniz.
