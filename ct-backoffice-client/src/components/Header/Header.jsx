import React from 'react';
import { useHistory } from 'react-router-dom';
import { Container, Image, Menu } from 'semantic-ui-react';

const Header = ({ title }) => {
  const history = useHistory();
  const logout = () => {
    localStorage.removeItem('token');
    history.push('/');
  };

  return (
    <Menu fixed="top">
      <Container>
        <Menu.Item as="a" header className="_header-title">
          <Image size="tiny" src="logo.jpg" style={{ marginRight: '1.5em' }} />
          {title}
        </Menu.Item>
        <Menu.Item as="a" position="right" onClick={logout}>
          Sign out
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default Header;
