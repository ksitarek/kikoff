#!/usr/bin/env bash

function create_classlib_projects() {
  echo "Creating class library projects..."
  for project in "${CLASSLIB_PROJECTS[@]}"; do
    local output_dir="${MODULE_ROOT}/${project}"
    if [[ -f "${output_dir}/${project}.csproj" ]]; then
      echo "  Skipping existing project: ${project}"
      continue
    fi
    dotnet new classlib --name "${project}" --output "${output_dir}" >/dev/null
    strip_csproj "${output_dir}" "${project}"
    echo "  Created ${project}"
  done
}
