const themes = [
    {
        id: 1,
        name: 'Theme 1 theme-forty',
        css: '/theme-forty/index.html',
    },
    {
        id: 2,
        name: 'Theme 2 Theme-dimension',
        css: '/Theme-dimension/index.html',
    },
];

export function getThemes() {
    return themes;
}

export function getThemeById(id) {
    return themes.find(theme => theme.id === id);
}
