#!/usr/bin/env bash

function create_test_projects() {
  echo "Creating test projects..."
  for project in "${TEST_PROJECTS[@]}"; do
    local output_dir="${TESTS_ROOT}/${project}"
    if [[ -f "${output_dir}/${project}.csproj" ]]; then
      echo "  Skipping existing project: ${project}"
      continue
    fi
    dotnet new nunit --name "${project}" --output "${output_dir}" >/dev/null
    echo "  Created ${project}"
  done
}
