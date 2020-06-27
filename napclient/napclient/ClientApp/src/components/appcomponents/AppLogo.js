import React from 'react';


const AppLogo = () => {
    const iconPath = `${process.env.PUBLIC_URL}/assets/favicon.png`;
    return <img src={iconPath} height="20" width="20"/>;
};

export default AppLogo;