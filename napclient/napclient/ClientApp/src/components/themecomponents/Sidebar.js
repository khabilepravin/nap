import React from "react";
import { connect } from "react-redux";
import { NavLink, withRouter } from "react-router-dom";
import classNames from "classnames";

import { Badge, Collapse } from "reactstrap";



import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import AppLogo from "../appcomponents/AppLogo";

import routes from "../../routes/index";

import avatar from "../../assets/img/avatars/avatar.jpg";

const SidebarCategory = withRouter(
  ({
    name,
    badgeColor,
    badgeText,
    icon,
    isOpen,
    children,
    onClick,
    location,
    to
  }) => {
    const getSidebarItemClass = path => {
      return location.pathname.indexOf(path) !== -1 ||
        (location.pathname === "/" && path === "/dashboard")
        ? "active"
        : "";
    };

    return (
      <li className={"sidebar-item " + getSidebarItemClass(to)}>
        <span
          data-toggle="collapse"
          className={"sidebar-link " + (!isOpen ? "collapsed" : "")}
          onClick={onClick}
          aria-expanded={isOpen ? "true" : "false"}
        >
          <FontAwesomeIcon
            icon={icon}
            fixedWidth
            className="align-middle mr-2"
          />{" "}
          <span className="align-middle">{name}</span>
          {badgeColor && badgeText ? (
            <Badge color={badgeColor} size={18} pill className="sidebar-badge">
              {badgeText}
            </Badge>
          ) : null}
        </span>
        <Collapse isOpen={isOpen}>
          <ul id="item" className={"sidebar-dropdown list-unstyled"}>
            {children}
          </ul>
        </Collapse>
      </li>
    );
  }
);

const SidebarItem = withRouter(
  ({ name, badgeColor, badgeText, icon, location, to }) => {
    const getSidebarItemClass = path => {
      return location.pathname === path ? "active" : "";
    };

    return (
      <li className={"sidebar-item " + getSidebarItemClass(to)}>
        <NavLink to={to} className="sidebar-link" activeClassName="active">
          {icon ? (
            <React.Fragment>
              <FontAwesomeIcon
                icon={icon}
                fixedWidth
                className="align-middle mr-2"
              />{" "}
              <span className="align-middle">{name}</span>
            </React.Fragment>
          ) : (
            name
          )}{" "}
          {badgeColor && badgeText ? (
            <Badge color={badgeColor} size={18} pill className="sidebar-badge">
              {badgeText}
            </Badge>
          ) : null}
        </NavLink>
      </li>
    );
  }
);

class Sidebar extends React.Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  toggle = index => {
    // Collapse all elements
    Object.keys(this.state).forEach(
      item =>
        this.state[index] ||
        this.setState(() => ({
          [item]: false
        }))
    );

    // Toggle selected element
    this.setState(state => ({
      [index]: !state[index]
    }));
  };

  componentWillMount() {
    /* Open collapse element that matches current url */
    const pathName = this.props.location.pathname;

    routes.forEach((route, index) => {
      const isActive = pathName.indexOf(route.path) === 0;
      const isOpen = route.open;
      const isHome = route.containsHome && pathName === "/" ? true : false;

      this.setState(() => ({
        [index]: isActive || isOpen || isHome
      }));
    });
  }

  render() {
    const { sidebar } = this.props;

    return (
      <nav
        className={classNames(
          "sidebar",
          sidebar.isOpen || "toggled",
          !sidebar.isOnRight || "sidebar-right"
        )}
      >
        <div className="sidebar-content">
          <a
            className={classNames(
              "sidebar-brand",
              !sidebar.isOnRight || "text-right"
            )}
            href="/"
          >
            {sidebar.isOnRight || <AppLogo/>}{" "}
            <span className="align-middle">Prac Test</span>{" "}
            {!sidebar.isOnRight || <AppLogo/>}
          </a>

          <div className="sidebar-user">
            <img
              src={avatar}
              className="img-fluid rounded-circle mb-2"
              alt="Linda Miller"
            />
            <div className="font-weight-bold">Linda Miller</div>
            <small>Front-end Developer</small>
          </div>
          <ul className="sidebar-nav">
            {routes.map((category, index) => {
              return (
                <React.Fragment key={index}>
                  {category.header ? (
                    <li className="sidebar-header">{category.header}</li>
                  ) : null}

                  {category.children ? (
                    <SidebarCategory
                      name={category.name}
                      badgeColor={category.badgeColor}
                      badgeText={category.badgeText}
                      icon={category.icon}
                      to={category.path}
                      isOpen={this.state[index]}
                      onClick={() => this.toggle(index)}
                    >
                      {category.children.map((route, index) => (
                        !route.hiddenInSideBar ? (<SidebarItem
                          key={index}
                          name={route.name}
                          to={route.path}
                          badgeColor={route.badgeColor}
                          badgeText={route.badgeText}
                        />) : null
                      ))}
                    </SidebarCategory>
                  ) : (
                    <SidebarItem
                      name={category.name}
                      to={category.path}
                      icon={category.icon}
                      badgeColor={category.badgeColor}
                      badgeText={category.badgeText}
                    />
                  )}
                </React.Fragment>
              );
            })}
          </ul>
        </div>
      </nav>
    );
  }
}

export default withRouter(
  connect(store => ({
    sidebar: store.sidebar
  }))(Sidebar)
);
