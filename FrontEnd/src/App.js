import React, { useState, useEffect } from 'react';
import './App.css';
import axios from 'axios';

function App() {
    const [themes, setThemes, getThemeById] = useState([]);
    const [selectedTheme, setSelectedTheme] = useState(null);

    useEffect(() => {
        axios.get('/api/themes')
            .then(response => {
                setThemes(response.data);
            })
            .catch(error => {
                console.error('Error fetching themes:', error);
            });
    }, []);

    useEffect(() => {
        if (selectedTheme) {
            loadTheme(selectedTheme);
        }
    }, [selectedTheme]);

    const loadTheme = (theme) => {
        const link = document.createElement('link');
        link.rel = 'stylesheet';
        link.href = theme.css;
        document.head.appendChild(link);
    };

    const handleThemeChange = (theme) => {
        getThemeById(theme.id);
       // setSelectedTheme(theme)
    };

    return (
        <div className="App">
            <h1>Available Themes</h1>
            <ul>
                {themes.map(theme => (
                    <li key={theme.id} onClick={() => handleThemeChange(theme.id)}>
                        {theme.name}
                    </li>
                ))}
            </ul>

            <h1 id="tabelLabel">Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {/* Your weather forecast table component goes here */}
        </div>
    );
}

export default App;
