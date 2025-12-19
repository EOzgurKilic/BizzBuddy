import "./App.css";

type ChecklistItem = {
  label: string;
  done?: boolean;
};

const checklist: ChecklistItem[] = [
  { label: "Node.js 18+ kurulu" },
  { label: "Terminalde frontend klasöründe: npm install" },
  { label: "Geliştirme: npm run dev (Rider Run/Debug ile de çalışır)" },
  { label: "API adresini .env.local içine yaz: VITE_API_BASE_URL=http://localhost:5000/api" },
  { label: "Tarayıcıda listelenen portu aç (genelde 5173)" }
];

function App() {
  return (
    <div className="page">
      <header className="hero">
        <p className="badge">Yeni React projesi</p>
        <h1>BizzBuddy Frontend</h1>
        <p className="lede">
          Bu arayüz, backend API&apos;nize bağlanmak için sıfırdan oluşturuldu. Rider içinde
          açıp npm komutlarını terminalden veya Run/Debug yapılandırmasıyla çalıştırabilirsiniz.
        </p>
        <a className="cta" href="https://vitejs.dev/guide/" target="_blank" rel="noreferrer">
          Vite rehberini aç
        </a>
      </header>

      <section className="card">
        <h2>Başlarken</h2>
        <ul className="checklist">
          {checklist.map((item) => (
            <li key={item.label}>
              <span className="check" aria-hidden="true">{item.done ? "✓" : "•"}</span>
              {item.label}
            </li>
          ))}
        </ul>
        <p className="hint">
          Rider menüsünden <strong>New Terminal</strong> açıp yukarıdaki adımları uygulayabilir veya
          <strong> Add Configuration → npm → dev</strong> seçerek scriptleri IDE içinden çalıştırabilirsiniz.
        </p>
      </section>

      <section className="card">
        <h2>API bağlantısı</h2>
        <p>
          Ortam değişkeni tanımladıktan sonra istekleri aşağıdaki örnekle başlatabilirsiniz:
        </p>
        <pre className="code">
{`const API_URL = import.meta.env.VITE_API_BASE_URL;

fetch(\`${'${API_URL}'}/health\`)
  .then((res) => res.json())
  .then(console.log)
  .catch(console.error);
`}
        </pre>
        <p className="hint">
          CORS hatası alırsanız backend ayarlarını kontrol edin veya Vite proxy yapılandırmasını
          <code>vite.config.ts</code> içinde ekleyin.
        </p>
      </section>
    </div>
  );
}

export default App;
