// src/FAQList.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

function FAQList() {
    const [faqs, setFaqs] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:5001/api/FAQ') // URL de votre API backend
            .then(response => setFaqs(response.data))
            .catch(error => console.error('Erreur lors de la récupération des FAQs :', error));
    }, []);

    return (
        <div>
            <h2>FAQs</h2>
            <ul>
                {faqs.map(faq => (
                    <li key={faq.id}>
                        <strong>{faq.question}</strong>: {faq.answer}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default FAQList;