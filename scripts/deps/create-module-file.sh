#!/usr/bin/env bash

# ── Template ──────────────────────────────────────────────────────────────────
# Generates the {ModuleName}Module.cs file for the Infrastructure project.
# Edit the heredoc below to customise the generated class.

function module_file_template() {
  local solution_name="$1"
  local module_name="$2"

  cat <<EOF
namespace ${solution_name}.Modules.${module_name}.Infrastructure;

using ${solution_name}.BuildingBlocks.Modules;

public sealed class ${module_name}Module : IModule;
EOF
}

# ── Create file ───────────────────────────────────────────────────────────────

function create_module_file() {
  local infra_dir="${MODULE_ROOT}/${PROJECT_INFRASTRUCTURE}"
  local file_path="${infra_dir}/${MODULE_NAME}Module.cs"

  if [[ -f "${file_path}" ]]; then
    echo "  Skipping existing module file: ${MODULE_NAME}Module.cs"
    return
  fi

  dotnet add "${infra_dir}" reference "${REPO_ROOT}/src/BuildingBlocks/${SOLUTION_NAME}.BuildingBlocks.Modules/${SOLUTION_NAME}.BuildingBlocks.Modules.csproj" >/dev/null

  dotnet add "${REPO_ROOT}/src/${SOLUTION_NAME}.Api/${SOLUTION_NAME}.Api.csproj" reference "${infra_dir}/${PROJECT_INFRASTRUCTURE}.csproj" >/dev/null

  mkdir -p "${infra_dir}"
  module_file_template "${SOLUTION_NAME}" "${MODULE_NAME}" > "${file_path}"
  echo "  Created ${MODULE_NAME}Module.cs"
}
