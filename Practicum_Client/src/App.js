import './App.css';
import Routers from './components/Routers';
import { BrowserRouter } from 'react-router-dom';

function App() {
  return (
    <div className="App" dir="rtl">
      <BrowserRouter>
        <Routers />
      </BrowserRouter>
    </div>
  );
}

export default App;