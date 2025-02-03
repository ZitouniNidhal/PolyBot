// src/App.js
import React from 'react';
import FAQList from './FAQList'; // Import du composant FAQList
import './styles.css'; // Import des styles globaux (optionnel)

function App() {
    return (
        <div className="App">
            <header>
                <h1>PolyBot - Assistant Virtuel</h1>
            </header>
            <main>
                <FAQList /> {/* Affiche la liste des FAQs */}
            </main>
        </div>
    );
}

export default App;