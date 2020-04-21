import React from 'react';
import Header from '../Header/Header';
import Footer from '../Footer/Footer';

const Layout = (props) => {
  const { children } = props;
  return (
    <>
      <Header title="Contact Tracing BackOffice" />
      <div className="children">{children}</div>
      <Footer />
    </>
  );
};

export default Layout;
