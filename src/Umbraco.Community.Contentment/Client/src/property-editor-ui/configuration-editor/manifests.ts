// SPDX-License-Identifier: MPL-2.0
// Copyright © 2024 Lee Kelleher

import type { ManifestModal, ManifestPropertyEditorUi } from '@umbraco-cms/backoffice/extension-registry';

const modals: Array<ManifestModal> = [
	{
		type: 'modal',
		alias: 'Umb.Contentment.Modal.ConfigurationEditor.Selection',
		name: '[Contentment] Configuration Editor Selection Modal',
		element: () => import('./configuration-editor-selection-modal.element.js'),
	},
  {
		type: 'modal',
		alias: 'Umb.Contentment.Modal.ConfigurationEditor.Workspace',
		name: '[Contentment] Configuration Editor Workspace Modal',
		element: () => import('./configuration-editor-workspace-modal.element.js'),
	},
];

const editorUi: ManifestPropertyEditorUi = {
	type: 'propertyEditorUi',
	alias: 'Umb.Contentment.PropertyEditorUi.ConfigurationEditor',
	name: '[Contentment] Configuration Editor Property Editor UI',
	element: () => import('./configuration-editor.element.js'),
	meta: {
		label: '[Contentment] Configuration Editor',
		icon: 'icon-settings-alt',
		group: 'data',
	},
};

export const manifests = [...modals, editorUi];