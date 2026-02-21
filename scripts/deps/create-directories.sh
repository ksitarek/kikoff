#!/usr/bin/env bash

function create_directories() {
  mkdir -p "${MODULE_ROOT}" "${TESTS_ROOT}"
  echo "Created directories."
}
