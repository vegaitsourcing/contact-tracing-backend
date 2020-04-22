import React from 'react';
import { useHistory } from 'react-router-dom';
import { Container, Image, Menu } from 'semantic-ui-react';
import { logout } from '../../store/actions/userAction';
import { useDispatch } from 'react-redux';

const Header = ({ title }) => {
  const history = useHistory();
  const dispatch = useDispatch();

  const signOut = () => {
    localStorage.removeItem('token');
    dispatch(logout());
    history.push('/');
  };

  return (
    <Menu fixed="top">
      <Container>
        <Menu.Item as="a" header className="_header-title">
          <Image size="tiny" src="logo.jpg" style={{ marginRight: '1.5em' }} />
          {title}
        </Menu.Item>
        <Menu.Item as="a" position="right" onClick={signOut}>
          Sign out
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default Header;
