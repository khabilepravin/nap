import * as types from "../constants";

export function toggleSidebar() {
  return {
    type: types.SIDEBAR_VISIBILITY_TOGGLE
  };
}

export function showSidebar() {
  return {
    type: types.SIDEBAR_VISIBILITY_SHOW
  };
}

export function hideSidebar() {
  return {
    type: types.SIDEBAR_VISIBILITY_HIDE
  };
}

export function enableRightSidebar() {
  return {
    type: types.SIDEBAR_RIGHT_ENABLE
  };
}

export function disableRightSidebar() {
  return {
    type: types.SIDEBAR_RIGHT_DISABLE
  };
}
